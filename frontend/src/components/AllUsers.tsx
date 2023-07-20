import {userAPI} from "../Redux/UserApi";
import RegistrationForm from "./RegistrationForm";
import ProfileCard from "./ProfileCard";

const AllUsers = () =>{
    const {data: users} = userAPI.useGetAllUsersQuery();

    return (
        <>
            {!users || users.length === 0 ? (
                <h1>Пользователи не найдены</h1>
            ) : (
                users.map((user) => <ProfileCard user={user} />)
            )}
        </>
    );
};

export default AllUsers;