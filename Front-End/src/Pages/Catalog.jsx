import { useEffect, useState } from "react";
import Product from "../Components/Product";
import { Get } from "../Request";

export default function CatalogPage() {

    const productLoading = { loading: true }
    const [products, setProducts] = useState([productLoading, productLoading, productLoading]);
    const [error, setError] = useState(null);

    useEffect(() => {

        GetProducts();

    }, [])

    /**
     * Obter produtos.
     */
    async function GetProducts() {
        try {

            const result = await Get("/products");
            const list = Array.isArray(result) ? result : [];
            setProducts(list);

        } catch (error) {
            console.error("> FALHA AO BUSCAR LISTA DE PRODUTOS", error);
            setError(error);
        }
    }

    /**
     * Comprar produto.
     */
    async function BuyProduct() {

    }

    return (
        <>
            <div className="container-fluid p-5">
                <div className="row">

                    {
                        error &&
                        <>
                            <div class="alert alert-danger" role="alert">
                                <ul className="mb-0">
                                    {
                                        error.messages.map((message) => <li>{message}</li>)
                                    }
                                </ul>
                            </div>
                        </>
                    }

                    {
                        products.map((product) =>
                            <>
                                <div className="col-12 col-md-6 col-lg-6 col-xxl-4">
                                    <Product {...product} />
                                </div>
                            </>
                        )
                    }
                </div>
            </div>
        </>
    )
}