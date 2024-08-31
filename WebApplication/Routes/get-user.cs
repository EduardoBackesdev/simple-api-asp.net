namespace getUserNameSpace;

public static class getUser
{
    public static List<Usuario> UsuariosList = new (){
        new (Guid.NewGuid(), "Eduardo"),
        new (Guid.NewGuid(), "Andriele"),
        new (Guid.NewGuid(), "Oliver")
    };

    public static void mapGetUser(this WebApplication app){
        app.MapGet("/get-user", ()=> UsuariosList);

        app.MapGet("/get-user/{nome}", 
        (String nome)=> UsuariosList.Find((x) => x.Nome == nome));

        app.MapPost("/post-user", (Usuario user)=>{
            
            foreach (var item in UsuariosList)
            {
                if (user.Nome == item.Nome){
                    return Results.BadRequest(new {Message = "Usuario ja cadastrado"});
                } 
                
            }
            UsuariosList.Add(user);
            return Results.Ok(new {Message = "Usuario cadastrado com sucesso"});
        });

        app.MapPut("/update-user/{nome}",
        (String nome, Usuario user)=>{
            var encontrado = UsuariosList.Find((x)=>x.Nome == nome);
            if (encontrado == null){
                return Results.NotFound(new {Message= "Usuario nao encontrado"});
            };

                encontrado.Nome = user.Nome;
                return Results.Ok(new {Message = "Usuario atualizado"});
            
            }
        );



    }
    
}