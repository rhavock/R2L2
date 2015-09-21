using MongoDB.Bson;
using MongoDB.Driver;
using R2L2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace R2L2.Infra
{
    public class Repositorio<Classe>:IRepositorio<Classe> where Classe : new()
    {
        public string StringConexao
        {
            get
            {
                return "mongodb://rhavock:rapper@ds041643.mongolab.com:41643/r2l2dev";
            }
        }
        public IMongoDatabase Conexao()
        {
            var client = new MongoClient(StringConexao);
            return client.GetDatabase("r2l2dev");

        }

        public virtual void Adicionar(Classe classe)
        {
            var produtos = Conexao().GetCollection<Classe>(classe.GetType().Name);
            produtos.InsertOneAsync(classe);
        }
        public virtual void Apagar(Classe classe, Expression<Func<Classe, bool>> query)
        {
            var produtos = Conexao().GetCollection<Classe>(classe.GetType().Name);
            produtos.DeleteOneAsync(query);
        }

        public virtual void Atualizar(Classe classe, Expression<Func<Classe, bool>> query)
        {
            var produtos = Conexao().GetCollection<Classe>(classe.GetType().Name);
            produtos.ReplaceOneAsync(query, classe);
        }

        public List<Classe> Listar(Classe classe)
        {
            var filter = new BsonDocument();
            var produtos = Conexao().GetCollection<Classe>(classe.GetType().Name);
            return produtos.Find(filter).ToListAsync().Result;
        }

        public virtual Classe Obter<TipoDado>(Classe classe, Expression<Func<Classe, TipoDado>> query, TipoDado valor) 
        {
            var conn = Conexao();
            var collection = conn.GetCollection<Classe>(classe.GetType().Name);
            var filter = Builders<Classe>.Filter.Eq(query, valor);
            if (collection.CountAsync(filter).Result == 0)
                return new Classe();

            return collection.Find(filter).SingleAsync().Result;
        }

        public List<Classe> Listar(Classe classe, Expression<Func<Classe, bool>> query)
        {
            var produtos = Conexao().GetCollection<Classe>(classe.GetType().Name);
            return produtos.Find(query).ToListAsync().Result;
        }
    }

}
