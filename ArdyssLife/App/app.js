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

        filters: {
            formatDate(val) {
                return moment(val).format('MM/DD/YYYY');
            }
        },

        methods: {
            initialize() {
                this.api.getCustomers().then(({ data }) => {
                    this.customers = data;
                })
            },

            nextStepOrder(item) {
                this.e1 = this.e1 + 1;
            }
        }
    })
})(window);