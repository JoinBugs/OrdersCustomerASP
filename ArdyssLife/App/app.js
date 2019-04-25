(function (ctx) {
    ctx.context = new Vue({
        el: '#app',
        data: () => ({
            api: window.api,
            customerNameSelected: null,
            customerSelected: null,
            headers: [
                { text: 'Id', value: 'CustomerId' },
                { text: 'Name', value: 'CustomerName' },
                { text: 'Status', value: 'CustomerStatus' },
                { text: 'Born Date', value: 'CustomerBornDate' },
                { text: 'Actions', value: 'name', sortable: false, align: 'center' }
            ],
            customers: [],
            e1: 1,

            orders_headers: [
                { text: 'Id', value: 'OrderId' },
                { text: 'Order Date', value: 'OrderDate' },
                { text: 'Sub total', value: 'Subtotal' },
                { text: 'Tax', value: 'Tax' },
                { text: 'Shipping', value: 'Shipping' },
                { text: 'Total', value: 'Total' },
                { text: 'Actions', value: 'name', sortable: false, align: 'center' }
            ],

            orders: [],

            dialog: false,
            dialogDelete: false,
            itemPosDelete: null,
            snackbar: {
                snackbar: false,
                color: 'info',
                mode: 'vertical',
                timeout: 6000,
                text: ''
            },

            editedIndex: -1,

            editedItem: {
                OrderId: 0,
                OrderDate: '',
                SubTotal: 0,
                Tax: 0,
                Shipping: 0,
                Total: 0
            },

            defaultItem: {
                OrderId: 0,
                OrderDate: '',
                SubTotal: 0,
                Tax: 0,
                Shipping: 0,
                Total: 0
            }
        }),

        computed: {
            formTitle() {
                return this.editedIndex === -1 ? 'Add New Order' : 'Edit Order'
            }
        },

        watch: {
            e1(val) {
                if (val == 1)
                    this.customerNameSelected = null;
            },
            dialog(val) {
                val || this.close()
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

            initializeOrders(customerId) {
                this.api.getOrders(customerId).then(({ data }) => {
                    this.orders = data.map(order => {
                        order.OrderDate = this.$options.filters.formatDate(order.OrderDate);
                        return order;
                    })
                })
            },

            nextStepOrder(item) {
                this.customerNameSelected = item.CustomerName;
                this.customerSelected = item;
                this.e1 = this.e1 + 1;
                this.initializeOrders(item.CustomerId);
            },

            editItem(item) {
                this.editedIndex = this.orders.indexOf(item);
                this.editedItem = Object.assign({}, item);
                this.dialog = true;
            },

            deleteItem(item) {
                this.itemPosDelete = item;
                this.dialogDelete = true;
            },

            onConfirmDeleteItem() {
                this.api.deleteOrder(this.itemPosDelete.OrderId).then(() => {
                    this.itemPosDelete = null;
                    this.dialogDelete = false;
                    this.snackbar.snackbar = true;
                    this.snackbar.text = "order deleted :)"
                    this.initializeOrders(this.customerSelected.CustomerId);
                })
            },

            onClickAddOrder() {
                this.editedItem.OrderDate = this.$options.filters.formatDate(new Date())
            },

            close() {
                this.dialog = false
                setTimeout(() => {
                    this.editedItem = Object.assign({}, this.defaultItem)
                    this.editedIndex = -1
                }, 300)
            },

            save() {
                let action = this.editedIndex > -1 ? this.api.putOrder : this.api.postOrder;
                let customerId = this.customerSelected.CustomerId;
                this.editedItem.CustomerId = customerId;
                action(this.editedItem).then(() => {
                    this.snackbar.snackbar = true;
                    this.snackbar.text = "order saved :)"
                    this.initializeOrders(customerId);
                    this.close()
                });
            }
        }
    })
})(window);