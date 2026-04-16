import { Outlet } from "react-router-dom";

const AuthLayout = () => {
  return (
    <div className="flex flex-col p-5 w-full h-screen bg-background">
      <Outlet />
    </div>
  );
};

export default AuthLayout;
