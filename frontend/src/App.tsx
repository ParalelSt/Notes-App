import MainLayout from "./components/layout/MainLayout";
import { Route, Routes } from "react-router-dom";
import Home from "./components/Pages/Home";
import AuthLayout from "./components/layout/AuthLayout";
import Auth from "./components/Pages/Auth";
import ProtectedRoute from "./components/layout/ProtectedRoute";

function App() {
  return (
    //ADD ABSOLUTE IMPORTS

    <>
      <Routes>
        <Route element={<AuthLayout />}>
          <Route path="/auth" element={<Auth />} />
        </Route>

        <Route element={<ProtectedRoute />}>
          <Route element={<MainLayout />}>
            <Route path="/" element={<Home />} />
          </Route>
        </Route>
      </Routes>
    </>
  );
}

export default App;
