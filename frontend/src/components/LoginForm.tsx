import React, {useState} from "react";

const LoginForm = () => {
    const [login, setLogin] = useState("");
    const [password, setPassword] = useState("");
    const [showForm, setShowForm] = useState(false);

    const handleButtonClick = () => {
        setShowForm(true);
    };

    const handleSubmit = (event: React.FormEvent) => {
        event.preventDefault();
    };

    return (
        <div>
            {!showForm && <button onClick={handleButtonClick}>Авторизация</button>}
            {showForm && (
                <form onSubmit={handleSubmit}>
                    <p>Авторизация</p>
                    <div>
                        <input placeholder={"Логин"} onChange={(e) => setLogin(e.target.value)}/>
                    </div>
                    <div>
                        <input placeholder={"Пароль"} onChange={(e) => setPassword(e.target.value)}/>
                    </div>
                    <div>
                        <button>Войти</button>
                    </div>
                </form>
            )}
        </div>
    );
};

export default LoginForm;