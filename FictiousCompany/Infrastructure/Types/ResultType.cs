using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace FictiousCompany.Infrastructure.Types
{
    public enum ResultType
    {
        [Description("Done Successfully!")]
        Successful,

        [Description("")]
        Warning,

        [Description("Error!")]
        Error,

        [Description("Please Fill Required Fields!")]
        FillRequiredFields,

        [Description("You're Not Allowed!")]
        AccessDenied,

        [Description("Nothing Found!")]
        NotFound,

        [Description("Duplicated!")]
        DuplicatedInformation,

        [Description("Symbol Is Duplicated!")]
        DuplicatedSymbol,

        [Description("Symbol Is Not Allowed!")]
        NotAllowedSymbol,

        [Description("Can Not Delete, Has Related Data!")]
        HasRelatedDataCanNotDelete,

        [Description("Can Not Delete!")]
        CanNotDelete,

        [Description("Sign-Up Failed!")]
        SignUpFailed,

        [Description("Username or Password not found!")]
        UsernameOrPasswordNotFound,

        [Description("Email confirmed successfully!")]
        EmailConfirmedSuccessfully,

        [Description("Error while confirming your email!")]
        ErrorConfirmingEmail,

        [Description("User not registered!")]
        UserNotRegistered,

        [Description("Invalid user token!")]
        InvalidUserToken,

        [Description("Account is locked out!")]
        AccountIsLockedOut,

        [Description("Username is not allowed!")]
        UsernameIsNotAllowed,

        [Description("Email is not confirmed!")]
        EmailIsNotConfirmed,

        [Description("User Type Is Not Company!")]
        UserTypeIsNotCompany,

        [Description("That email is taken! Try another.")]
        EmailIsNotUnique,

        [Description("That username is taken! Try another.")]
        UserIsNotUnique,

        [Description("execute failed")]
        Failed,
    }
}
