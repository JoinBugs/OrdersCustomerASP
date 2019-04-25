let api = window.api = {};

const config = {
    protocol: 'http',
    server: 'localhost',
    port: '52692',
    prefixEndpoint: 'api',
    resolve(resource = '', controler = 'customer') {
        return `${this.protocol}://${this.server}:${this.port}/${this.prefixEndpoint}/${controler}/${resource}`
    }
};

(function () {
    this.getCustomers = () => {
        return axios.get(config.resolve(''))
    }

    this.getOrders = customerId => {
        return axios.get(config.resolve)
    }
}).apply(api)