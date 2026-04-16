import { Outlet } from "react-router-dom";
import Nav from "./Nav";

const MainLayout = () => {
  return (
    <div className="flex flex-col p-5 w-full h-screen bg-background">
      <Nav />
      <Outlet />
    </div>
  );
};

export default MainLayout;
