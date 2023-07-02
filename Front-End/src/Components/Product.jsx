import { act } from "@testing-library/react";
import { DecimalToMoney } from "../Utils";

export default function Product(props) {

    const { id, name, description, stock, price, active } = props;

    return (
        <>

            <div className={"card m-2 " + (!active && "card-disabled")} style={{ maxWidth: 540 }} product-id={id} key={id}>
                <div className="row g-0">
                    <div className="col-md-4">
                        <img src="https://placehold.co/400x600" className="img-fluid rounded-start" alt="..." />
                    </div>
                    <div className="col-md-8">
                        <div className="card-body">
                            <h5 className="card-title">{name}</h5>
                            <p className="card-text">{description}</p>
                            <p className="card-text">
                                <small className="text-muted">
                                    {stock || 0} unidades disponíveis.
                                </small>
                            </p>

                            <h5>R$ {price ? DecimalToMoney(price) : "0,00"}</h5>

                            <button href="#" className="btn btn-success me-2" disabled={stock == 0 || !active}>
                                <i className="bi bi-bag-fill me-2"></i>
                                {stock == 0 ? "Indisponível" : "Comprar"}
                            </button>
                            <button href="#" className="btn btn-primary " disabled={!active}>
                                <i className="bi bi-box-arrow-up-right me-2"></i>
                                Detalhes
                            </button>
                        </div>

                    </div>
                </div>
            </div>

        </>
    );
}