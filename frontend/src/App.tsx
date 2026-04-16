import MainLayout from "./components/layout/MainLayout";
import { Route, Routes } from "react-router-dom";
import Home from "./components/Pages/Home";
import AuthLayout from "./components/layout/AuthLayout";
import Auth from "./components/Pages/Auth";

function App() {
  return (
    //ADD ABSOLUTE IMPORTS

    <>
      <Routes>
        <Route element={<AuthLayout />}>
          <Route path="/auth" element={<Auth />} />
        </Route>
        <Route element={<MainLayout />}>
          <Route path="/" element={<Home />} />
        </Route>
      </Routes>
    </>
  );
}

export default App;
