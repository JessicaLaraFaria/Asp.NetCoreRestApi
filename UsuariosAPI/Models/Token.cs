﻿using Google.Protobuf.WellKnownTypes;

namespace UsuariosAPI.Models
{
    public class Token
    {
        public Token(string value)
        {
            Value = value;
        }
        public string Value { get;}
    }
}
