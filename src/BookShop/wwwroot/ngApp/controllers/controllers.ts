namespace BookShop.Controllers {

    export class HomeController {
        public message = 'Here are a bunch of your books!';
        public books;
        public book;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            $http.get('/api/books').then((results) => {
                this.books = results.data;
            });

        }

        public saveBook(book) {
            this.$http.post('/api/books', this.book).then((results) => {
                this.$state.reload();
            })
                .catch((reason) => {
                    console.log(reason);
                    console.log(book);
                });
        }
    }


    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }


    export class AboutController {
        public message = 'Hello from the about page!';
    }

    export class BookDetailController {
        public book;

        constructor(private $http: ng.IHttpService, private $stateParams: ng.ui.IStateParamsService, private $state: ng.ui.IStateService) {
            $http.get(`/api/books/${$stateParams['id']}`)
                .then((response) => {
                    this.book = response.data;
                    console.log(this.book);
                });

        }
        public editBook(book) {
            this.$http.put(`/api/books/${this.book.id}`, this.book)
                .then((results) => {
                    this.$state.reload();
                })
                .catch((reason) => {
                    console.log(reason);
                });

        }

        public deleteBook(id) {
            this.$http.delete(`/api/books/${this.book.id}`).
                then((response) => {
                    this.$state.go('home');
                });
        }
    }
}