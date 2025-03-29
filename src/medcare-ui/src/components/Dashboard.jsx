import { useContext } from "react";
import { AuthContext } from "./Auth/AuthContext";

const Dashboard = () => {
    const { currUser } = useContext(AuthContext);

    return (
      <div className="mt-15">
        <h1>Здравствуйте, {currUser.firstName} {currUser.lastName} {currUser.patronymic}</h1>
        <h2>    Ваша роль, {currUser.userRole}</h2>
      </div>  
    );
}

export default Dashboard;
