interface Usuarios;
public class Usuario
{
    public Guid Id { get; set;}
    public String Nome { get; set;}

    public Usuario(Guid id, String nome){
        Id = id;
        Nome = nome;
    }
}