using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Tarcizio.Domain.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public DateTime? Birth { get; set; }
        public String Phone { get; set; }
        public List<Address> Addresses { get; set; }
        public Status Status { get; set; }

        public int GetNumberOfAddresses()
        {
            return Addresses.Count;
        }

        public int GetZipCode()
        {
            return Addresses.Count;
        }

        public void BusinessRules()
        {
            NameMandatory();
            EmailMandatory();
            PhoneFormat();
        }

        public void NameMandatory()
        {
            if (String.IsNullOrWhiteSpace(this.Name))
            {
                throw new NullException("the name field is required");
            }
        }

        public void EmailMandatory()
        {
            if (String.IsNullOrWhiteSpace(this.Email))
            {
                throw new NullException("the Email field is required");
            }
        }

        public void Active()
        {
            this.Status = Status.Active;
        }

        public void Inactive()
        {
            this.Status = Status.Inactive;
        }

        public void PhoneFormat()
        {
            const string RegExForValidation = @"^$|\(\d{0,2}\) \d{4,5}\-\d{0,4}";
            Regex regex = new Regex(RegExForValidation);
            Match match = regex.Match(this.Phone);

            if (!match.Success)
            {
                throw new InvalidPhoneException("Invalid Phone format. Use  (99) 09999-9999.");
            }

        }

    }
}
