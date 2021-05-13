using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string TokenCreated="Token oluşturuldu";
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string PasswordError="Hatalı şifre";
        public static string LoginSuccessful="Kayıt başarılı";
        public static string UserRegistered="Kayıt Başarılı";
        public static string UserAlreadyExist="Kullanıcı zaten var";
        public static string CarAdded="Araç eklendi";
        public static string CarDeleted= "Araç silindi";
        public static string CarUpdated= "Araç güncellendi";
        public static string BrandAdded="Model eklendi";
        public static string BrandDeleted="Model silindi";
        public static string BrandUpdated="Model güncellendi";
        public static string ColarAdded="Renk eklendi";
        public static string ColarDeleted="Renk silindi";
        public static string ColarUpdated="Renk güncellendi";
        public static string CustomerAdded="Müşteri eklendi";
        public static string CustomerDeleted="Müşteri silindi";
        public static string CustomerUpdated="Müşteri güncellendi";
        public static string AuthorizationDenied="Yetkisiz giriş";
        public static string MinumumCarNameLength="Araç ismi minimum 2 karakter olmalıdır";
        public static string MaximumCarNameLength= "Araç ismi maksimum 10 karakter olabilir";
        public static string CarNameCanNotBeEmpty="Araç ismi boş kalamaz";
        public static string DescrpitionCanNotBeEmpty="Açıklama boş kalamaz";
        public static string DailyPriceCanNotBeEmpty="Günlük araç kirası boş kalamaz";
        public static string MinumumCustomerNameLength= "Müşteri ismi minimum 2 karakter olmalıdır";
        public static string MaximumCustomerNameLength= "Müşteri ismi maksimum 20 karakter olabilir";
        public static string CustomerNameCanNotBeEmpty="Müşteri ismi boş kalamaz";
        public static string CanNotBeforeToday="Bugünden öncesine ait bir tarih girilemez";
        public static string RentDateCanNotBeEmpty="Kiralama tarihi boş kalamaz";
        public static string MinumumBrandNameLength= "Model ismi minimum 2 karakter olmalıdır";
        public static string MaximumBrandNameLength= "Model ismi maksimum 20 karakter olabilir";
        public static string BrandNameCanNotBeEmpty="Model ismi boş bırakılamaz";
        public static string MinumumColarNameLength= "Renk ismi minimum 2 karakter olmalıdır";
        public static string MaximumColarNameLength= "Renk ismi maksimum 30 karakter olabilir";
        public static string ColarNameCanNotBeEmpty="Renk ismi boş bırakılamaz";
        internal static string CheckImageCount;
    }
}
