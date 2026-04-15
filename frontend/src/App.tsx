import Layout from "./components/layout/Layout";
import Nav from "./components/layout/Nav";
import Home from "./components/Pages/Home";
import { Route, Routes } from "react-router-dom";

function App() {
  return (
    //ADD ABSOLUTE IMPORTS

    <>
      <Layout>
        <Routes>
          <Route path="/" element={<Home />} />
        </Routes>
      </Layout>
      <Nav />
    </>
  );
}

export default App;
