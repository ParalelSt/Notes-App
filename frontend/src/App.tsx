import ImportantNote from "./components/ImportantNote";
import Layout from "./components/layout/Layout";
import Note from "./components/Note";

function App() {
  return (
    //ADD ABSOLUTE IMPORTS

    <Layout>
      <Note />
      <ImportantNote />
    </Layout>
  );
}

export default App;
