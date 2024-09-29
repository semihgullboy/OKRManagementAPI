namespace TekhnelogosOkr.Business.Constants
{
    public static class Messages
    {
        //HATA MESAJLARI

        public const string UserAuthenticated = "Giriş başarılı bir şekilde gerçekleşti.";
        public const string UserAuthenticationFailed = "Şifreniz hatalı bir şekilde girildi.";
        public const string UserNotFound = "Ldap sisteminde kullanıcı bulunamadı.";
        public const string UserDbNotFound = "Giriş yetkiniz bulunamadı.";
        public const string GeneralException = "LDAP oturum açma sırasında bir hata oluştu.";

        public const string DepartmentAdded = "Departman başarılı bir şekilde kaydedildi.";
        public const string DepartmentsListed = "Departmanlar başarılı bir şekilde listelendi.";
        public const string DepartmentListed = "Departman başarılı bir şekilde listelendi.";
        public const string DepartmentDeleted = "Departman başarılı bir şekilde silindi.";
        public const string DepartmentUpdated = "Departman başarılı bir şekilde güncellendi.";
        public const string DepartmentNotFound = "Departman bulunamadı";
        public const string DepartmentIdFetched = "Departman ID başarıyla alındı.";

        public const string UserAdded = "Kullanıcı başarılı bir şekilde kaydedildi.";
        public const string UserAddedFailed = "Kullanıcı eklenirken bir hata gerçekleşti.";
        public const string UsersListed = "Kullanıcılar başarılı bir şekilde listelendi.";
        public const string UserListed = "Kullancı başarılı bir şekilde listelendi.";
        public const string UserListedFailed = "Kullanıcı listelenirken bir hata gerçekleşti.";
        public const string UserDeactivated = "Kullanıcını durumu güncellendi.";
        public const string UserDeactivationFailed = "Kullanıcının durumu güncellenirken bir hata gerçekleşti.";
        public const string UserUpdatedFailed = "Kullanıcı başarılı bir şekilde güncellendi.";
        public const string UserUpdated = "Kullancı güncellenirken bir hatay gerçekleşti.";

        public const string StatuesListed = "Statüler başarılı bir şekilde listelendi.";

        public const string CompanyObjectiveSuccessAdded = "Şirket hedefi başarılı bir şekilde kaydedildi.";
        public const string CompanyObjectiveFailedAdded = "Şirket hedefi eklenirken bir hatayla karşılaşıldı.";
        public const string CompanyObjectivesListed = "Şirket hedefi başarılı bir şekilde listelendi.";
        public const string CompanyObjectivesFailedListed = "Şirket hedefi listelenirken bir hatayla karşılaşıldı.";
        public const string CompanyObjectiveSuccessDeleted = "Şirket hedefi başarılı bir şekilde silindi.";
        public const string CompanyObjectiveFailedDeleted = "Şirket hedefi silinirken bir hatayla karşılaşıldı.";
        public const string CompanyObjectiveSuccessUpdated = "Şirket hedefi başarılı bir şekilde güncellendi.";
        public const string CompanyObjectiveFailedUpdated = "Şirket hedefi güncellenirken bir hatayla karşılaşıldı.";
        public const string CompanyObjectiveNotFound = "Şirket hedefi bulunamadı.";

        public const string KeyResultSuccessAdded = "Key Result başarılı bir şekilde kaydedildi.";
        public const string KeyResultFailedAdded = "Key Result eklenirken bir hatayla karşılaşıldı.";
        public const string KeyResultListed = "Key Result başarılı bir şekilde listelendi.";
        public const string KeyResultFailedListed = "Key Result listelenirken bir hatayla karşılaşıldı.";
        public const string KeyResultSuccessDeleted = "Key Result başarılı bir şekilde silindi.";
        public const string KeyResultFailedDeleted = "Key Result silinirken bir hatayla karşılaşıldı.";
        public const string KeyResultSuccessUpdated = "Key Result başarılı bir şekilde güncellendi.";
        public const string KeyResultFailedUpdated = "Key Result güncellenirken bir hatayla karşılaşıldı.";
        public const string KeyResultNotFound = "Key Result bulunamadı.";

        public const string ObjectiveAddedRole = "Bu hedefi eklemeniz için departman menajeri olmanız gerekmetedir.";
        public const string ObjectiveAddedSuccess = "Hedef başarıyla eklendi.";
        public const string ObjectiveAddedFailed = "Hedef eklenirken bir hata oluştu.";
        public const string ObjectiveDeletedSuccess = "Hedef başarıyla silindi.";
        public const string ObjectiveDeletedFailed = "Hedef silinirken bir hata oluştu.";
        public const string ObjectiveListedFailed = "Hedef listelenirken bir hata oluştu.";
        public const string ObjectiveListedSuccess = "Hedef başarılı bir şekilde listelendi.";
        public const string ObjectiveUpdatedSuccess = "Hedef başarıyla güncellendi.";
        public const string ObjectiveUpdatedFailed = "Hedef güncellenirken bir hata oluştu.";
        public const string ObjectiveNotFound = "Hedef bulunamadı.";
        public const string ObjectivesListedSuccess = "Hedefler başarılı bir şekilde listelendi.";
        public const string ObjectivesListedFailed = "Hedefler listelenirken bir hata oluştu.";

        public const string SuggestionSuccess = "İşlem başarıyla gerçekleşti.";
        public const string SuggestionNotFound = "İşlem bulunmadı.";
        public const string SuggestionError = "İşlem  gerçekleşirken bir hata oluştu.";

        public const string OkrObjectiveTransactionSucces = "Başarıyla kaydedildi.";
        public const string OkrObjectiveTransactionFailed = "Bir hata oluştu.";
        public const string OkrObjectiveTransactionNotFound = "İşlem bulunamadı.";

        public const string ManagerNotFound = "Kullanıcıya ait yönetici bulunamadı.";
        public const string ManagerInformationRetrievedSuccessfully = "Yönetici bilgileri başarıyla alındı.";
        public const string ErrorRetrievingManager = "Kullanıcı yöneticisi alınırken bir hata oluştu.";

        public const string RoleNotFound = "Rol bulunamadı.";
        public const string RoleUpdateFailed = "Rol güncelleme işlemi başarısız oldu.";
        public const string RoleUpdateSuccess = "Rol başarıyla güncellendi.";
        public const string UserRoleNotFound = "Kullanıcıya ait role bulunamadı.";
        public const string RolesListed = "Roller başarılı bir şekilde listelendi.";

        public const string KeyResultTransactionSuccessAdded = "Key Result işlemi başarılı bir şekilde kaydedildi.";
        public const string KeyResultTransactionFailedAdded = "Key Result  işlemi eklenirken bir hatayla karşılaşıldı.";
    }
}