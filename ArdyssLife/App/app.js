(function (ctx) {
    ctx.context = new Vue({
        el: '#app',
        data: () => ({
            api: window.api,
            customerNameSelected: null,
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
            e1(val) {
                if (val == 1)
                    this.customerNameSelected = null;
            }
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
                this.customerNameSelected = item.CustomerName;
                this.e1 = this.e1 + 1;
            }
        }
    })
})(window);