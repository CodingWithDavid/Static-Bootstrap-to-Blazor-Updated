using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Shared
{
    public class FooterModel
    {
        public AddressModel Address { get; set; } = new AddressModel();
        public SocialLinks SocialLinks { get; set; } = new SocialLinks();

        public string About { get; set; }
        public string Message { get; set; }


    }
}
