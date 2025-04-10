$(document).ready(function () 
{
    loadPosts();
});

// Função para carregar os posts.
function loadPosts() 
{
    $.get("http://localhost:5088/api/posts", function (data) 
    {
        var postsContainer = $("#postsContainer");
        postsContainer.empty();
        data.forEach(function (post) 
        {
            postsContainer.append(`
                <div class="post">
                    <img src="images/default_profile_pic.jpg" alt="Imagem de Perfil" style="width: 50px; height: 50px;">
                    <p><strong>${post.user.username}</strong></p>
                    <p>${post.content}</p>
                    <small>${post.createdAt}</small>
                    <br>
                    <button onclick="deletePost(${post.id})">Excluir</button>
                </div>
            `);
        });
    });
}

// Função para excluir um post.
function deletePost(id) 
{
    $.ajax
    (
        {
            url: `http://localhost:5088/api/posts/${id}`,
            type: "DELETE",
            success: function () 
            {
                // Recarrega os posts após a exclusão.
                loadPosts(); 
            }
        }
    );
}

// Função para adicionar um novo post.
function addPost() 
{
    var post = 
    {
        // Captura o conteúdo inserido pelo usuário.
        content: $("#content").val()  
    };

    $.ajax
    (
        {
        url: "http://localhost:5088/api/posts",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(post),
        success: function () 
        {
            // Recarrega os posts após a adição.
            loadPosts(); 
            // Limpa o campo de texto.
            $("#content").val(""); 
        }
        }
    );
}

// Função para exibir o formulário de adicionar post.
function showAddPostForm() 
{
    $("#addPostForm").show();
}

// Função para esconder o formulário de adicionar post.
function hideAddPostForm() 
{
    $("#addPostForm").hide();
}
