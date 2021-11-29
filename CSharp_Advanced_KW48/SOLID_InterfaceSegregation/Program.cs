// See https://aka.ms/new-console-template for more information
using System.Linq.Expressions;

Console.WriteLine("Hello, World!");


IRepository<Person> repository = new RepositoryBase<Person>();

//repository.Insert(new Person());
//repository.Delete(1);
//repository.Update(1, new Person())

//repository.GetAll();
//repository.GetByStatement
//repository.GetById(1);

IReadRepository<Person> readonlyRepository = new    RepositoryBase<Person>();
//readonlyRepository.GetAll();
//repository.GetById(1);
//repository.GetByStatement




IUpdateOperation updateOperation = new BetterRepository();
updateOperation.Update(123, new Person(1, "Harry Weinfuhrt"));

public interface IReadRepository<T>
{
    IList<T> GetAll();
    IList<T> GetByStatement(Expression<Func<int, bool>> predicate);
    T GetById(int Id);
}


public interface IRepository<T> : IReadRepository<T>
{
    public void Insert(T item);
    public void Update(int Id, T modifiedItem);

    public void Delete(int Id);


    //IList<T> GetAll();
    //IList<T> GetByStatement(Expression<Func<int, bool>> predicate);
    //T GetById(int Id);
}


public class RepositoryBase<T> : IRepository<T>
{

    //DbContext -> Verbindung zu DB
    public void Delete(int Id)
    {
        throw new NotImplementedException();
    }

    public IList<T> GetAll()
    {
        throw new NotImplementedException();
    }

    public T GetById(int Id)
    {
        throw new NotImplementedException();
    }

    public IList<T> GetByStatement(Expression<Func<int, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public void Insert(T item)
    {
        throw new NotImplementedException();
    }

    public void Update(int Id, T modifiedItem)
    {
        throw new NotImplementedException();
    }
}

public record Person(int Id, string Name);


#region Goode Code

public interface IInsertOperation
{
    void Insert();
}

public interface IUpdateOperation
{
    void Update(int id, Person p);
}

public interface IDeleteOperation
{
    void Delete(int id);
}

public interface IReadOperation
{
    void GetAll();
    void GetById(int Id);
}

public interface IRepository2 : IInsertOperation, IUpdateOperation, IDeleteOperation, IReadOperation
{
    //kann man weiteres noch implementieren 
}

public class BetterRepository : IRepository2
{
    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public void GetAll()
    {
        throw new NotImplementedException();
    }

    public void GetById(int Id)
    {
        throw new NotImplementedException();
    }

    public void Insert()
    {
        throw new NotImplementedException();
    }

    public void Update(int id, Person p)
    {
        throw new NotImplementedException();
    }
}
#endregion