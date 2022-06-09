function Footer() {
    return (
        <div className="container">
            <footer className="py-3 my-4">
                <ul className="nav justify-content-center border-bottom pb-3 mb-3">
                    <li className="nav-item">
                        <a href="#" className="nav-link px-2 text-muted">Home</a>
                    </li>
                    <li className="nav-item">
                        <a href="#" className="nav-link px-2 text-muted">Produtos</a>
                    </li>
                    <li className="nav-item">
                        <a href="#" className="nav-link px-2 text-muted">Quem somos</a>
                    </li>
                    <li className="nav-item">
                        <a href="#" className="nav-link px-2 text-muted">Contato</a>
                    </li>
                </ul>
                <p className="text-center text-muted">&copy; 2022 Supermercado Piróquitos</p>
                <p className="text-center text-muted">&copy; Autoria de Matheus Filipe dos Santos Reinert</p>
            </footer>
        </div>
    );
}

export default Footer;