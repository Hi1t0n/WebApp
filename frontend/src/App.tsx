import React from 'react';
import logo from './logo.svg';
import RegistrationForm from "./components/RegistrationForm";
import ProfileCard from "./components/ProfileCard";
import LoginForm from "./components/LoginForm";
import AllUsers from "./components/AllUsers";


function App() {
  return (
      <div>
        <RegistrationForm></RegistrationForm>
        <LoginForm></LoginForm>
        <h1>Список пользователей:</h1>
        <AllUsers></AllUsers>
      </div>
  );
}

export default App;
