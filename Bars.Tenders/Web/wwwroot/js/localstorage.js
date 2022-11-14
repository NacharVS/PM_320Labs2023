function AddUserToLocalStorage(login, passwordHash) {
    localStorage.setItem("login", login);
    localStorage.setItem("passwordHash", passwordHash);
}

function GetLogin()
{
    return localStorage.getItem("login");
}

function GetPasswordHash()
{
    return localStorage.getItem("passwordHash");
}

function ClearLocalStorage()
{
    localStorage.clear();
}