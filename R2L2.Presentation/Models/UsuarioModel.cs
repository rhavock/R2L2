﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2L2.Domain;

namespace R2L2.Presentation.Models
{
    public class UsuarioModel
    {
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Imagem { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public UsuarioModel()
        {
        }

        public IEnumerable<UsuarioModel> CriarModel(List<Usuario> list)
        {
            foreach (var item in list)
            {
                yield return new UsuarioModel
                {
                    Email = item.Email,
                    Imagem = item.Imagem,
                    Login = item.Login,
                    Nome = item.Nome,
                    Senha = item.Senha,
                    Telefone = item.Telefone
                };
            }
        }
    }
}
