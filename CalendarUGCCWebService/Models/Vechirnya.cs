using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarUGCCWebService.Models
{
    public class Vechirnya
    {
        public enum Type
        {
            Shchodenna,
            UPjatnycju,
            IzSvjatymNa6,
            Nedilna,
            IzSvjatymPolijelejnym,
            IzSvjatymBdibnym,
            BogorodychneSvjato,
            GospodskeSvjato
        }

        public Vechirnya()
        {

        }
        public Vechirnya(Day day)
        {
            var type = GetTypeOfVechirnya();

            if (type == Type.Shchodenna ||
                type == Type.UPjatnycju ||
                type == Type.IzSvjatymNa6)
            {
                GetUsualStart();
            }
            else
            {
                GetNonUsualStart();
            }

            Get103PsAndEktenia();

            if (type == Type.Shchodenna ||
                type == Type.UPjatnycju ||
                type == Type.IzSvjatymNa6)
            {
                GetUsualKatyzma();
            }
            else
            {
                GetNonUsualKatyzma();
            }

            GetStyhyry(day, type);

            GetSvitloTyhe(day);

            //TODO Add all methods to generate text of Vechirnya

        }

        private void GetSvitloTyhe(Day day)
        {
            throw new NotImplementedException();
        }

        private void GetStyhyry(Day day, Type type)
        {
            throw new NotImplementedException();
        }

        private void GetNonUsualKatyzma()
        {
            throw new NotImplementedException();
        }

        private void GetUsualKatyzma()
        {
            throw new NotImplementedException();
        }

        private void Get103PsAndEktenia()
        {
            throw new NotImplementedException();
        }

        private void GetNonUsualStart()
        {
            throw new NotImplementedException();
        }

        private void GetUsualStart()
        {
            throw new NotImplementedException();
        }

        private void GetStart()
        {
            throw new NotImplementedException();
        }

        private Type GetTypeOfVechirnya()
        {
            //TODO implement type selection for vechirnya
            return Type.Shchodenna;
        }

    }
}