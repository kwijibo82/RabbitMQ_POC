using System;
using System.Collections.Generic;
using System.Text;

namespace Receiver.Model.DTO
{
    class UserObjectDTO
    {
        public UserObjectDTO(AddressDTO _addressDTO, CompanyDTO _companyDTO, GeoDTO _geoDTO, UserDTO _userDTO)
        {
            this.addresDTO = _addressDTO;
            this.companyDTO = _companyDTO;
            this.geoDTO = _geoDTO;
            this.userDTO = _userDTO;
        }

        private AddressDTO addresDTO { get; set; }
        private CompanyDTO companyDTO { get; set; }
        private GeoDTO geoDTO { get; set; }
        private UserDTO userDTO { get; set; }
    }
}
