using Core.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Product Added";
        public static string ProductDeleted = "Product Deleted";
        public static string ProductUpdated = "Product Updated";
        public static string productVerified = "Product Verified";

        public static string CategoryDeleted = "Category Deleted";
        public static string CategoryUpdated = "Category Updated";
        public static string CategoryAdded = "Category Added";

        public static string SupplierAdded = "SupplierAdded";
        public static string SupplierDeleted = "Supplier Deleted";
        public static string SupplierUpdated = "Supplier Updated";

        public static string CustomerAdded = "Customer Added";
        public static string CustomerDeleted = "Customer Deleted";
        public static string CustomerUpdated = "Customer Updated";

        public static string TradeSuccess = "Trade is Success";
        public static string TradeDeleted = "Trade is Deleted";
        public static string TradeUpdated = "Trade is Updated";

        public static string AuthorizationDenied = "Yetkiniz bulunmamaktadır";
        internal static string UserRegistered = "Kayıt Olundu";
        internal static string UserNotFound = "Kullanıcı Bulunamadı";
        internal static string PasswordError = "Şifreyi Yanlış girdiniz";
        internal static string SuccessfulLogin = "Başarıyla giriş yapıldı.";
        internal static string UserAlreadyExists = "Kullanıcı zaten mevcur.";
        internal static string AccessTokenCreated = "Giriş Tokenı Yaratıldı";

    }
}
