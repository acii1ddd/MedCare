const API_URL = "https://localhost:7009/api";

export const signIn = async (login, password) => {
    try {
        const response = await fetch(`${API_URL}/auth/sign-in`, {
            method: "POST",
            headers: 
            {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                "login": login,
                "password": password
            })
        });

        const accessTokenModel = await response.json();
        if (response.ok) {
            localStorage.setItem("token", accessTokenModel.accessToken);
            return accessTokenModel;
        }
        else if (response.status === 404) {
            throw new Error("Введите корректный логин!");
        }
        else if (response.status === 400) {
            throw new Error("Введите корректный пароль!");
        }
    } catch (error) {
        console.log("Ошибка при аутентификации ", error);
        throw error;
    }
}

export const getCurrUser = async () => {
    const token = localStorage.getItem("token");
    if (!token) return null;

    try {
        const response = await fetch(`${API_URL}/auth/curr-user`, {
            method: "GET",
            headers: {
                "Authorization": `Bearer ${token}`
            }
        });
        return await response.json();
    } catch (error) {
        console.log("Ошибка при получении роли пользователя", error);
        throw error;
    }
}

export const logout = () => {
    localStorage.removeItem("token");
}
