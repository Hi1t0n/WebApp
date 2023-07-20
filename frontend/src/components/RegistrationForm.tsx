import React, {useState} from "react";
import {userAPI} from "../Redux/UserApi";
import {IUser} from "../interface/IUser";


const RegistrationForm = () =>{
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [login, setLogin] = useState("");
    const [password, setPassword] = useState("");
    const [email, setEmail] = useState("");
    const [birthdayDate, setBirthdayDate] = useState("");
    const [phoneNumber, setPhoneNumber] = useState("");
    const [showForm, setShowForm] = useState(false);
    const [createPost,{}] = userAPI.useRegisterMutation();

    const handleCreate = async () => {
        const user: IUser = {id:0,firstName,lastName,login,password, email,phoneNumber,birthdayDate};
        await createPost(user);
    }
    const handleButtonClick = () => {
        setShowForm(true);
    };

    const handleSubmit = (event: React.FormEvent) => {
        event.preventDefault();
    };

    return (
        <div>
            {!showForm && <button onClick={handleButtonClick}>Регистрация</button>}
            {showForm && (
                <form onSubmit={handleSubmit}>
                    <p>Регистрация</p>
                    <div>
                        <p><input id={"Login"} placeholder={"Логин"} onChange={(e) => setLogin(e.target.value)}/></p>
                        <p><input placeholder={"Пароль"} onChange={(e) => setPassword(e.target.value)}/></p>
                        <p><input placeholder={"Имя"} onChange={(e) => setFirstName(e.target.value)}/></p>
                        <p><input placeholder={"Фамилия"} onChange={(e) => setLastName(e.target.value)}/></p>
                        <p><input placeholder={"Эл.Почта"} onChange={(e) => setEmail(e.target.value)}/></p>
                        <p><input placeholder={"Номер телефона"} onChange={(e) => setPhoneNumber(e.target.value)}/></p>
                        <p><input type="date" placeholder={"Дата рождения"} onChange={(e) => setBirthdayDate(e.target.value)}/></p>
                    </div>
                    <button onClick={handleCreate}>Зарегистрироваться</button>
                </form>
            )}
        </div>
    );
};

export default RegistrationForm;