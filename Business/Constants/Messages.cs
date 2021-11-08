using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
     static class Messages
    {
        public static string AuthorizationDenied = "Bu işlemi yapmak için yetkiniz yok.";
        public static string Deleted = "Silme işlemi başarılı.";
        public static string Debitted = "Zimmet işlemi başarılı.";
        public static string Updated = "Güncelleme işlemi başarılı.";
        public static string Added = "Ekleme işlemi başarılı.";
        public static string UserAlreadyExists = "Böyle bir kullanıcı zaten var.";
        public static string AccessTokenCreated = "Token Oluşturuldu";
        public static string ImageFailed = "Fotoğraf yüklenirken bir hata oluştu.";
    }
}
