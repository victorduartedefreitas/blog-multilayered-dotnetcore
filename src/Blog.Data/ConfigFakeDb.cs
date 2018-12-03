using Blog.Data.Model;
using System;
using System.Collections.Generic;

namespace Blog.Data
{
    public static class ConfigFakeDb
    {
        public static IList<User> InitUsers()
        {
            var users = new List<User>();

            var addressUser1 = new Address
            {
                AddressType = AddressTypes.Residential,
                City = "Contagem",
                Street = "Rua Beta, 100",
                Suite = "Ap 101",
                ZipCode = "32123321"
            };

            var phoneUser1 = new Phone
            {
                Number = "31987654321",
                PhoneType = PhoneTypes.Mobile
            };

            var addressUser2 = new Address
            {
                AddressType = AddressTypes.Residential,
                City = "Belo Horizonte",
                Street = "Rua Alfa, 123",
                ZipCode = "31260200"
            };

            var user1 = new User
            {
                Email = "victor@email.com",
                Name = "Victor Duarte de Freitas",
                UserId = 1,
                UserName = "victordfreitas"
            };
            user1.Adresses.Add(addressUser1);
            user1.Phones.Add(phoneUser1);

            var user2 = new User
            {
                Email = "teste@email2.com",
                Name = "Usuário de Teste",
                UserId = 2,
                UserName = "teste123"
            };

            user2.Adresses.Add(addressUser2);

            users.Add(user1);
            users.Add(user2);

            return users;
        }

        public static IList<Post> InitPosts()
        {
            var posts = new List<Post>();

            var post1 = new Post
            {
                PostId = 1,
                UserId = 1,
                Title = "Post de Teste 1",
                Body = "Este é um post de teste número 1. Este post tem como objetivo testar a API.",
                CreationDate = DateTimeOffset.Now
            };

            var post2 = new Post
            {
                PostId = 2,
                UserId = 2,
                Title = "Post de Teste 2",
                Body = "Este é apenas mais um post de teste número 2.",
                CreationDate = DateTimeOffset.Now
            };

            var post3 = new Post
            {
                PostId = 3,
                UserId = 2,
                Title = "Post 3 bla bla bla",
                Body = "Este é um post de teste número 3 bla bla bla bla bla bla.",
                CreationDate = DateTimeOffset.Now
            };

            var post4 = new Post
            {
                PostId = 4,
                UserId = 1,
                Title = "Post 4 Post 4",
                Body = "Post 4 bla bla bla Post 4 bla bla bla Post 4 bla bla bla Post 4 bla bla bla",
                CreationDate = DateTimeOffset.Now
            };

            var post5 = new Post
            {
                PostId = 5,
                UserId = 2,
                Title = "Post 5",
                Body = "Este é o 5º post de teste. Sim, já estou aqui pela 5ª vez.",
                CreationDate = DateTimeOffset.Now
            };

            var post6 = new Post
            {
                PostId = 6,
                UserId = 2,
                Title = "Post de número 6",
                Body = "É, este já é o post de número 6. Vamos lá, só mais uns 2 de teste e eu termino.",
                CreationDate = DateTimeOffset.Now
            };

            var post7 = new Post
            {
                PostId = 7,
                UserId = 1,
                Title = "Post de número 7 já",
                Body = "Este é o penúltimo. Estamos quase lá. Vamo que vamo, Brasil.",
                CreationDate = DateTimeOffset.Now
            };

            var post8 = new Post
            {
                PostId = 8,
                UserId = 2,
                Title = "Finalmente, post 8",
                Body = "Este é o último post de teste para inicializar o banco de dados fake. Espero que neste ponto esteja tudo certo.",
                CreationDate = DateTimeOffset.Now
            };

            posts.AddRange(new Post[] { post1, post2, post3, post4, post5, post6, post7, post8 });

            return posts;
        }

        public static IList<Comment> InitComments()
        {
            var comments = new List<Comment>();

            var c1 = new Comment
            {
                CommentId = 1,
                PostId = 1,
                Name = "Fulano",
                Email = "naotenhoemail@email.com",
                Body = "Nossa, que belas palavras. Continue assim."
            };

            var c2 = new Comment
            {
                CommentId = 2,
                PostId = 1,
                Name = "Cicrano",
                Email = "eutambemnaotenhoemail@email.com",
                Body = "Não gostei. Tome cuidado com suas palavras, rapaz. Vivemos numa \"democracia\"."
            };

            var c3 = new Comment
            {
                CommentId = 3,
                PostId = 1,
                Name = "Fulano",
                Email = "naotenhoemail@email.com",
                Body = "Cicrano, tá falando de mim, é? Discutir aqui não vai levar a nada. PAZ. =)"
            };

            var c4 = new Comment
            {
                CommentId = 4,
                PostId = 4,
                Name = "Beltrano",
                Email = "beltrano@email.com",
                Body = "bla bla bla bla bla bla bla bla bla pra você também."
            };

            var c5 = new Comment
            {
                CommentId = 5,
                PostId = 7,
                Name = "Maria",
                Email = "maria@email.com",
                Body = "Estamos na torcida por você. Vamos lá, você consegue. Só mais um pouco e você termina o BD Fake. =)"
            };

            var c6 = new Comment
            {
                CommentId = 6,
                PostId = 7,
                Name = "Roberto",
                Email = "roberto@email.com",
                Body = "Também estou aqui na torcida, e com pipoca na mão. Vamos lá, rapaz. Você consegue."
            };

            comments.AddRange(new Comment[] { c1, c2, c3, c4, c5, c6 });

            return comments;
        }
    }
}
