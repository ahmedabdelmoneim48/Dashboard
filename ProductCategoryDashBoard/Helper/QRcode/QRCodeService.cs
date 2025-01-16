using QRCoder;
using System.Drawing;
using System.IO;

namespace DashBoard.PL.Helper.QRcode
{
    public class QRCodeService
    {
        public string GenerateQRCode(string data)
        {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                // Generate QR code data
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);

                // Create a QR code object from the data
                using (QRCode qrCode = new QRCode(qrCodeData))
                {
                    using (Bitmap qrCodeImage = qrCode.GetGraphic(20)) // 20 is the pixel size
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            // Save QR code to MemoryStream
                            qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();

                            // Return the QR code image as a Base64 string
                            return Convert.ToBase64String(byteImage);
                        }
                    }
                }
            }
        }
    }
}
