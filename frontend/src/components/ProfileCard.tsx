import React from "react";
import {IUser} from "../interface/IUser";

interface IProfileProps{
    user: IUser;
}

const ProfileCard = (props : IProfileProps) => (
    <div>
        <div>
            Имя: {props.user.firstName}
            Фамилия: {props.user.lastName}
            Телефон: {props.user.phoneNumber}
            Email: {props.user.email}
        </div>
    </div>
);

export default ProfileCard;