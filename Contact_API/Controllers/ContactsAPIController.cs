using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;



namespace Contact_API.Controllers
{
    public class ContactsAPIController : ApiController
    {
        // [Route("api/ContactsAPI/InsertCustomer")]
        [HttpPost]
        public Contact InsertCustomer(Contact _contact)
        {
            try
            {
                using (ContactsDBEntities entities = new ContactsDBEntities())
                {
                    entities.Contacts.Add(_contact);
                    entities.SaveChanges();
                }

                return _contact;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //[Route("api/ContactsAPI/UpdateCustomer")]    
        [HttpPut]
        public bool UpdateCustomer(Contact _contact)
        {
            try
            {
                using (ContactsDBEntities entities = new ContactsDBEntities())
                {
                    Contact updatedCustomer = (from c in entities.Contacts
                                               where c.ContactId == _contact.ContactId
                                               select c).FirstOrDefault();
                    updatedCustomer.FirstName = _contact.FirstName;
                    updatedCustomer.LastName = _contact.LastName;
                    entities.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //[Route("api/ContactsAPI/DeleteCustomer")]
        [HttpDelete]
        public void DeleteCustomer(Contact _contact)
        {
            try
            {

                using (ContactsDBEntities entities = new ContactsDBEntities())
                {
                    Contact contact = (from c in entities.Contacts
                                       where c.ContactId == _contact.ContactId
                                       select c).FirstOrDefault();
                    entities.Contacts.Remove(contact);
                    entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}