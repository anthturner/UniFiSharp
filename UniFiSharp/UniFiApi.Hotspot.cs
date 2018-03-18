using System.Collections.Generic;
using System.Threading.Tasks;
using UniFiSharp.Json;

namespace UniFiSharp
{
    public partial class UniFiApi
    {
        /// <summary>
        /// Retrieve a list of operators created for the hotspots run from this controller for this site
        /// </summary>
        /// <returns>A collection of JSON objects that describe operators registered on this controller for this site</returns>
        public async Task<IEnumerable<JsonHotspotOperator>> HotspotOperatorList()
        {
            return await RestClient.UniFiGetMany<JsonHotspotOperator>($"api/s/{Site}/rest/hotspotop");
        }

        /// <summary>
        /// Create a new operator for hotspots run from this controller for this site
        /// </summary>
        /// <param name="name">Operator name</param>
        /// <param name="password">Operator password</param>
        /// <param name="note">Note to store with user record</param>
        /// <returns>A JSON object that describes the new operator</returns>
        public async Task<JsonHotspotOperator> HotspotOperatorAdd(string name, string password, string note = "")
        {
            return await RestClient.UniFiPost<JsonHotspotOperator>($"api/s/{Site}/rest/hotspotop", new
            {
                @name = name,
                x_password = password,
                note = note
            });
        }

        /// <summary>
        /// Retrieve a list of vouchers created for the hotspots run from this controller for this site
        /// </summary>
        /// <returns>A collection of JSON objects that describe vouchers registered on this controller for this site</returns>
        public async Task<IEnumerable<JsonHotspotVoucher>> HotspotVoucherList()
        {
            return await RestClient.UniFiGetMany<JsonHotspotVoucher>($"api/s/{Site}/stat/voucher");
        }

        /// <summary>
        /// Create a new voucher for hotspots run from this controller for this site
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="down"></param>
        /// <param name="up"></param>
        /// <param name="expire"></param>
        /// <param name="quota"></param>
        /// <param name="note"></param>
        /// <returns>A JSON object that describes the new vouches</returns>
        public async Task<JsonHotspotVoucher> HotspotVoucherAdd(long bytes, long down, long up, string expire, string quota, string note)
        {
            return await RestClient.UniFiPost<JsonHotspotVoucher>($"api/s/{Site}/cmd/hotspot", new
            {
                bytes = bytes,
                cmd = "create-voucher",
                down = down,
                expire = expire,
                expire_number = 1,
                expire_unit = "1440",
                note = note,
                quota = quota,
                up = up
            });
        }

        /// <summary>
        /// Delete a voucher from hotspots run from this controller for this site
        /// </summary>
        /// <param name="id">Voucher ID to delete</param>
        /// <returns></returns>
        public async Task HotspotVoucherDelete(string id)
        {
            await RestClient.UniFiPost($"api/s/{Site}/cmd/hotspot", new
            {
                _id = id,
                cmd = "delete-voucher",
            });
        }

        /// <summary>
        /// Retrieve a list of guests using the hotspots
        /// </summary>
        /// <param name="withinNHours">If specified, returns guests who have accessed the hotspots in the last N hours</param>
        /// <returns></returns>
        public async Task<IEnumerable<JsonGuest>> HotspotGuestList(int withinNHours = -1)
        {
            if (withinNHours > 0)
                return await RestClient.UniFiGetMany<JsonGuest>($"api/s/{Site}/stat/guest?within={withinNHours}");
            else
                return await RestClient.UniFiGetMany<JsonGuest>($"api/s/{Site}/stat/guest");
        }

        /// <summary>
        /// Retrieve a list of guests' payment information for guests using the hotspots
        /// </summary>
        /// <param name="withinNHours">If specified, returns payment information for guests who have accessed the hotspots in the last N hours</param>
        /// <returns></returns>
        public async Task<IEnumerable<JsonPaymentTransactionInformation>> HotspotPaymentList(int withinNHours = -1)
        {
            if (withinNHours > 0)
                return await RestClient.UniFiGetMany<JsonPaymentTransactionInformation>($"api/s/{Site}/stat/payment?within={withinNHours}");
            else
                return await RestClient.UniFiGetMany<JsonPaymentTransactionInformation>($"api/s/{Site}/stat/payment");
        }
    }
}
