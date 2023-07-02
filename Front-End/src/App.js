import logo from "./logo.svg";
import "./App.css";
import NavBar from "./Components/NavBar";
import Product from "./Components/Product";
import Footer from "./Components/Footer";

function App() {
  const produto01 = {
    id: 1,
    name: "Produto 01",
    description:
      "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent congue.",
    active: true,
    stock: 8,
    price: 989.87,
    active: true,
  };

  const produto02 = {
    id: 2,
    name: "Produto 02",
    description:
      "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent congue.",
    active: true,
    stock: 2,
    price: 1407.97,
    active: true,
  };

  const produto03 = {
    id: 3,
    name: "Produto 03",
    description:
      "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent congue.",
    active: true,
    stock: 0,
    price: 452.77,
    active: true,
  };

  return (
    <>
      <NavBar />

      <div className="container-fluid p-5">
        <div className="row">
          <div className="col-12 col-md-6 col-lg-6 col-xxl-4">
            <Product {...produto01} />
          </div>
          <div className="col-12 col-md-6 col-lg-6 col-xxl-4">
            <Product {...produto02} />
          </div>
          <div className="col-12 col-md-6 col-lg-6 col-xxl-4">
            <Product {...produto03} />
          </div>
        </div>
      </div>

      <Footer />
    </>
  );
}

export default App;
