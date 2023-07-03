import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { DecimalToMoney } from "../Utils";

export default function ViewProductPage() {

    const { productID } = useParams();
    const [product, setProduct] = useState(null);
    const [success, setSuccess] = useState(null);
    const [error, setError] = useState(null);
    const [loading, setLoading] = useState(false);
    const { name, description, price, stock, active } = product || { stock: 1, active: true };


    useEffect(() => {

        GetProduct();


    }, []);

    /**
     * Obter produto.
     */
    async function GetProduct() {

        // const result = await Get(`/products/${productID}`);

    }

    /**
     * Comprar produto.
     */
    async function BuyProduct() {

    }

    return (
        <>



            <div className="container pt-5">
                <div className="row justify-content-center">

                    {/* Imagem */}
                    <div className="col-5">

                        <div id="carouselExample" className="carousel slide carousel-fade carousel-dark">
                            <div className="carousel-inner">
                                <div className="carousel-item active">
                                    <img src="https://placehold.co/550x400" className="img-fluid rounded" alt="..." />
                                </div>
                                <div className="carousel-item">
                                    <img src="https://placehold.co/550x400/orange/white" className="img-fluid rounded" alt="..." />
                                </div>
                                <div className="carousel-item">
                                    <img src="https://placehold.co/550x400/blue/white" className="img-fluid rounded" alt="..." />
                                </div>
                            </div>
                            <button
                                className="carousel-control-prev"
                                type="button"
                                data-bs-target="#carouselExample"
                                data-bs-slide="prev"
                            >
                                <span className="carousel-control-prev-icon" aria-hidden="true" />
                                <span className="visually-hidden">Previous</span>
                            </button>
                            <button
                                className="carousel-control-next"
                                type="button"
                                data-bs-target="#carouselExample"
                                data-bs-slide="next"
                            >
                                <span className="carousel-control-next-icon" aria-hidden="true" />
                                <span className="visually-hidden">Next</span>
                            </button>
                        </div>


                    </div>

                    {/* Informações */}
                    <div className="col-6">

                        <div>
                            <h3>{name || "Lorem ipsum dolor sit amet."}</h3>
                        </div>

                        <div className="mt-3">
                            <label class="produto-details-label">Descrição</label>
                            <p>{description || "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam placerat lacinia dolor. Aenean elementum dignissim fringilla. Pellentesque vulputate, diam sed maximus pulvinar, lorem magna tristique nulla, ut pretium est dui vel mi. Etiam ex nunc, tristique vitae felis id, porta lobortis odio. Sed viverra commodo ex, eget commodo lorem aliquam."}</p>
                        </div>




                        <div className="mt-3">
                            <h2>
                                <span>
                                    R$ {price ? DecimalToMoney(price) : "0,00"}
                                </span>
                                <small className="d-block text-muted small" style={{ fontSize: "12.8px" }}>
                                    10x R$ {price ? DecimalToMoney(price / 10) : "0,00"} sem juros.
                                </small>
                            </h2>
                        </div>

                        <div className="mt-3">
                            <label class="produto-details-label">Disponibilidade</label>
                            <p>{stock || 0} unidades disponíveis.</p>
                        </div>

                        <div className="row">

                            <div className="col-12">
                                {
                                    stock == 0 || !active ?
                                        <>
                                            <button className="btn btn-outline-secondary" style={{ width: "100%" }}>
                                                <i class="bi bi-send me-2"></i>
                                                Avise-me quando chegar
                                            </button>
                                        </>
                                        :
                                        <>
                                            <button className="btn btn-primary" style={{ width: "100%" }}>
                                                <i className="bi bi-cart-plus-fill me-2"></i>
                                                Adicionar ao Carrinho
                                            </button>

                                            <button className="btn btn-success mt-2" style={{ width: "100%" }}>
                                                <i className="bi bi-bag-fill me-2"></i>
                                                Comprar Agora
                                            </button>


                                        </>
                                }
                            </div>




                            <div className="col-12 mt-2">

                            </div>
                        </div>


                        {/* <button href="#" className="btn btn-primary " disabled={!active} >
                            <i className="bi bi-box-arrow-up-right me-2"></i>
                            Detalhes
                        </button> */}


                    </div>


                </div>
            </div>



        </>
    );
}