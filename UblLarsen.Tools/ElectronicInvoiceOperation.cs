using SDKNETFrameWorkLib.GeneralLogic;

namespace UblLarsen.Tools
{
    public class ElectronicInvoiceOperation
    {
        // HASHING 
        public static ResultValue GenerateEInvoiceHashing(string filePath)
        {
            var res = new ResultValue();
            var _IHashingValidator = new SDKNETFrameWorkLib.BLL.HashingValidator();
            var objResult = _IHashingValidator.GenerateEInvoiceHashing(filePath);
            if (objResult != null)
            {
                res.IsValid = objResult.IsValid;
                res.ResultedValue = objResult.ResultedValue;
            }
            return res;
        }
        public static ResultValue ValidateEInvoiceHashing(string filePath)
        {
            var res = new ResultValue();
            var _IHashingValidator = new SDKNETFrameWorkLib.BLL.HashingValidator();
            var objResult = _IHashingValidator.ValidateEInvoiceHashing(filePath);
            if (objResult != null)
            {
                res.IsValid = objResult.IsValid;
                res.ResultedValue = objResult.ResultedValue;
            }
            return res;
        }

        // QR CODE
        public static ResultValue GenerateEInvoiceQRCode(string filePath)
        {
            var res = new ResultValue();
            var _IQRValidator = new SDKNETFrameWorkLib.BLL.QRValidator();
            var objResult = _IQRValidator.GenerateEInvoiceQRCode(filePath);
            if (objResult != null)
            {
                res.IsValid = objResult.IsValid;
                res.ResultedValue = objResult.ResultedValue;
            }
            return res;
        }
        public static ResultValue ValidateEInvoiceQRCode(string filePath)
        {
            var res = new ResultValue();
            var _IQRValidator = new SDKNETFrameWorkLib.BLL.QRValidator();
            var objResult = _IQRValidator.ValidateEInvoiceQRCode(filePath);
            if (objResult != null) {
                res.IsValid = objResult.IsValid;
                res.ResultedValue = objResult.ResultedValue;
            }
            return res;
        }


        // Validate Invoice 
        public static ResultValue ValidateEInvoice(string filePath,string cert,string pIH)
        {
            var res = new ResultValue();
            var _IEInvoiceValidator = new SDKNETFrameWorkLib.BLL.EInvoiceValidator();
            var objResult = _IEInvoiceValidator.ValidateEInvoice(filePath, cert, pIH);
            if (objResult != null)
            {
                res.IsValid = objResult.IsValid;
                res.ResultedValue = objResult.ResultedValue;
            }
            return res;
        }


        // Sign Document 
        public static ResultValue SignDocument(string filePath, string cert, string privatekey)
        {
            var res = new ResultValue();
            var _IEInvoiceSigningLogic = new SDKNETFrameWorkLib.BLL.EInvoiceSigningLogic();
            var objResult = _IEInvoiceSigningLogic.SignDocument(filePath, cert, privatekey);
            if (objResult != null)
            {
                res.IsValid = objResult.IsValid;
                res.ResultedValue = objResult.ResultedValue;
            }
            return res;
        }
    }
}
