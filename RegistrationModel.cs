using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ecommerce.Data;

namespace Ecommerce.Models
{
    public class RegistrationModel
    {
        public int Registration_ID { get; set; }
        public string Registration_FullName { get; set; }
        public string Registration_Email { get; set; }
        public Nullable<decimal> Registration_Mobile { get; set; }
        public string Registration_Address { get; set; }
        public string Registration_Country { get; set; }

        public string SaveRegistration(RegistrationModel model)
        {
            string msg = "Saved Successfully";
            EcomEntities db = new EcomEntities();
            {
                if (model.Registration_ID == 0)
                {
                    var SavData = new tblRegistration()
                    {
                        Registration_FullName = model.Registration_FullName,
                        Registration_Email = model.Registration_Email,
                        Registration_Mobile = model.Registration_Mobile,
                        Registration_Address = model.Registration_Address,
                        Registration_Country = model.Registration_Country,
                    };
                    db.tblRegistrations.Add(SavData);
                    db.SaveChanges();
                }
                else
                {
                    var getdata = db.tblRegistrations.Where(p => p.Registration_ID == model.Registration_ID).FirstOrDefault();
                    if (getdata != null)
                    {
                        getdata.Registration_ID = model.Registration_ID;
                        getdata.Registration_FullName = model.Registration_FullName;
                        getdata.Registration_Email = model.Registration_Email;
                        getdata.Registration_Mobile = model.Registration_Mobile;
                        getdata.Registration_Address = model.Registration_Address;
                        getdata.Registration_Country = model.Registration_Country;
                    };
                    db.SaveChanges();
                    msg = "Updated OR Edit Successfully";
                }
                return msg;
            }
        }

        public List<RegistrationModel> ListRegistration()
        {
            EcomEntities db = new EcomEntities();
            List<RegistrationModel> lstCRUD = new List<RegistrationModel>();
            var List = db.tblRegistrations.ToList();
            if (List != null)
            {
                foreach (var CRUDlist in List)
                {
                    lstCRUD.Add(new RegistrationModel()
                    {
                        Registration_ID = CRUDlist.Registration_ID,
                        Registration_FullName = CRUDlist.Registration_FullName,
                        Registration_Email = CRUDlist.Registration_Email,
                        Registration_Mobile = CRUDlist.Registration_Mobile,
                        Registration_Address = CRUDlist.Registration_Address,
                        Registration_Country = CRUDlist.Registration_Country,
                    });
                }
            }
            return lstCRUD;
        }

        public RegistrationModel EditRegistration(int Registration_ID)
        {
            RegistrationModel model = new RegistrationModel();
            EcomEntities db = new EcomEntities();
            var getCRUD = db.tblRegistrations.Where(p => p.Registration_ID == Registration_ID).FirstOrDefault();
            if (getCRUD != null)
            {
                model.Registration_ID = getCRUD.Registration_ID;
                model.Registration_FullName = getCRUD.Registration_FullName;
                model.Registration_Email = getCRUD.Registration_Email;
                model.Registration_Mobile = getCRUD.Registration_Mobile;
                model.Registration_Address = getCRUD.Registration_Address;
                model.Registration_Country = getCRUD.Registration_Country;

            };
            return model;
        }

        public string DeleteRegistration(int Registration_ID)
        {
            string message = "Deleted Successfully";
            EcomEntities db = new EcomEntities();
            var deleteCRUD = db.tblRegistrations.Where(p => p.Registration_ID == Registration_ID).FirstOrDefault();
            if (deleteCRUD != null)
            {
                db.tblRegistrations.Remove(deleteCRUD);
            };
            db.SaveChanges();
            message = "Record Deleted Successfully";
            return message;
        }

        public RegistrationModel GetDetails(int Registration_ID)
        {
            RegistrationModel model = new RegistrationModel();
            EcomEntities db = new EcomEntities();
            var getCountryDetail = db.tblRegistrations.Where(p => p.Registration_ID == Registration_ID).FirstOrDefault();
            if (getCountryDetail != null)
            {
                model.Registration_ID = getCountryDetail.Registration_ID;
                model.Registration_FullName = getCountryDetail.Registration_FullName;
                model.Registration_Email = getCountryDetail.Registration_Email;
                model.Registration_Mobile = getCountryDetail.Registration_Mobile;
                model.Registration_Address = getCountryDetail.Registration_Address;
                model.Registration_Country = getCountryDetail.Registration_Country;
            }
            return model;
        }

    }
}