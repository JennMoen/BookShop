namespace BookShop.Controllers {

    export class AccountController {
        public externalLogins;

        public getUserName() {
            return this.accountService.getUserName();
        }

        public getClaim(type) {
            return this.accountService.getClaim(type);
        }

        public isLoggedIn() {
            return this.accountService.isLoggedIn();
        }

        public logout() {
            this.accountService.logout();
            this.$location.path('/login');
        }

        public getExternalLogins() {
            return this.accountService.getExternalLogins();
        }

        constructor(private accountService: BookShop.Services.AccountService, private $location: ng.ILocationService) {
            this.getExternalLogins().then((results) => {
                this.externalLogins = results;
            });
        }
    }

    angular.module('BookShop').controller('AccountController', AccountController);


    export class LoginController {
        public loginUser;
        public validationMessages;

        public login() {
            this.accountService.login(this.loginUser).then(() => {
                if (this.accountService.getClaim('IsAdmin')) {
                    this.$location.path('/secret');
                }
                else {
                    this.$location.path('/');
                }
            }).catch((results) => {
                this.validationMessages = results;
            });
        }

        constructor(private accountService: BookShop.Services.AccountService, private $location: ng.ILocationService) { }
    }


    export class RegisterController {
        public registerUser;
        public validationMessages;

        public register() {
            this.accountService.register(this.registerUser).then(() => {
                this.$location.path('/about');
            }).catch((results) => {
                this.validationMessages = results;
            });
        }

        constructor(private accountService: BookShop.Services.AccountService, private $location: ng.ILocationService) { }
    }





    export class ExternalRegisterController {
        public registerUser;
        public validationMessages;

        public register() {
            this.accountService.registerExternal(this.registerUser.email)
                .then((result) => {
                    this.$location.path('/');
                }).catch((result) => {
                    this.validationMessages = result;
                });
        }

        constructor(private accountService: BookShop.Services.AccountService, private $location: ng.ILocationService) {}

    }

    export class ConfirmEmailController {
        public validationMessages;

        constructor(
            private accountService: BookShop.Services.AccountService,
            private $http: ng.IHttpService,
            private $stateParams: ng.ui.IStateParamsService,
            private $location: ng.ILocationService
        ) {
            let userId = $stateParams['userId'];
            let code = $stateParams['code'];
            accountService.confirmEmail(userId, code)
                .then((result) => {
                    this.$location.path('/');
                }).catch((result) => {
                    this.validationMessages = result;
                });
        }
    }

}
