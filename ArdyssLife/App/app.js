(function (ctx) {
    ctx.context = new Vue({
        el: '#app',
        data: () => ({
            api: window.api,
            headers: [
                { text: 'Id', value: 'CustomerId' },
                { text: 'Name', value: 'CustomerName' },
                { text: 'Status', value: 'CustomerStatus' },
                { text: 'Born Date', value: 'CustomerBornDate' },
                { text: 'Actions', value: 'name', sortable: false, align: 'center' }
            ],
            customers: [],
            e1: 1
        }),

        computed: {
        },

        watch: {
        },

        created() {
            this.initialize()
        },

        methods: {
            initialize() {
                this.api.getCustomers().then(({ data }) => {
                    this.customers = data;
                })
            },

            nextStep(n) {
                if (n === this.steps) {
                    this.e1 = 1
                } else {
                    this.e1 = n + 1
                }
            }
        }
    })
})(window);