import { useEffect, useState } from "react";
import Product from "../Components/Product";

export default function HomePage() {


    const [products, setProducts] = useState([]);

    useEffect(() => {

        setProducts([produto01, produto02, produto03]);

    }, [])

    /**
     * Obter produtos.
     */
    async function GetProducts() {
        /* back end tem q saber se auth é de cliente ou de empresa para seguir a regra solicitada. */
    }

    /**
     * Comprar produto.
     */
    async function BuyProduct() {

    }


    const produto01 = {
        id: 1,
        name: "Produto 01",
        description:
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent congue.",
        active: true,
        stock: 8,
        price: 989.87,
        active: true,
        loading: true
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
            <div className="container-fluid p-5">
                <div className="row">
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
    );
}