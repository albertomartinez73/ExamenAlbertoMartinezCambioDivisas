using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using ExamenAlbertoMartinezCambioDivisas.DAL;
using ExamenAlbertoMartinezCambioDivisas.Services.JsonConverterService;

namespace ExamenAlbertoMartinezCambioDivisas.Services.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public CambioDivisasContext Context;
        public DbSet<T> Table;
        public IJsonConverter<T>  Conversor;

        protected GenericRepository()
        {
            this.Context = new CambioDivisasContext();
            this.Table = this.Context.Set<T>();
            this.Conversor = new JsonConverter<T>();
        }

        protected GenericRepository(CambioDivisasContext context)
        {
            this.Context = context;
            this.Table = context.Set<T>();
            this.Conversor = new JsonConverter<T>();
        }

        protected GenericRepository(CambioDivisasContext context, IJsonConverter<T> conversor)
        {
            this.Context = context;
            this.Table = context.Set<T>();
            this.Conversor = conversor;
        }

        public abstract Task CargarDatos();

        public virtual async Task Delete(object id)
        {
            T existing = await this.Table.FindAsync(id);
            this.Table.Remove(existing);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await this.Table.ToListAsync();
        }

        public virtual async Task<T> GetById(object id)
        {
            return await this.Table.FindAsync(id);
        }

        public virtual void Insert(T obj)
        {
            this.Table.Add(obj);

        }

        public virtual async Task Save()
        {
            await this.Context.SaveChangesAsync();
        }

        public virtual void Update(T obj)
        {
            this.Table.Attach(obj);
            this.Context.Entry(obj).State = EntityState.Modified;
        }
    }
}