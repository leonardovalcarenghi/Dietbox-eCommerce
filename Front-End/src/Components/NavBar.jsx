export default function NavBar(props) {
    return (
        <>
            <nav className="navbar navbar-expand-lg bg-primary navbar-dark">
                <div className="container-fluid">
                    <a className="navbar-brand" href="/">
                        Dietbox e-Commerce
                    </a>
                    <button
                        className="navbar-toggler"
                        type="button"
                        data-bs-toggle="collapse"
                        data-bs-target="#navbarSupportedContent"
                        aria-controls="navbarSupportedContent"
                        aria-expanded="false"
                        aria-label="Toggle navigation"
                    >
                        <span className="navbar-toggler-icon" />
                    </button>
                    <div className="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                        </ul>
                        <form className="d-flex">
                            <button className="btn btn-outline-light px-3 me-2" type="button">
                                <i class="bi bi-door-closed-fill me-2"></i>
                                Sair
                            </button>
                        </form>
                    </div>
                </div>
            </nav>

        </>
    )
}