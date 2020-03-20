<template>
    <div>
        <validation-observer ref="observer" v-slot="{validate,valid}">
            <form method="post" @submit.prevent="updateLamp">
                <label class="col-form-label">Nama Lampu</label>
                <validation-provider name="Nama Lampu" rules="required" v-slot="{errors}">
                    <input class="form-control" type="text" v-model="newLampu.NamaLampu" />
                    <span class="text-danger font-italic">{{errors[0]}}</span>
                </validation-provider>
                <br />

                <label class="col-form-label">Stock Lampu</label>
                <validation-provider name="Stock Lampu" rules="required" v-slot="{errors}">
                    <input class="form-control" type="text" v-model="newLampu.StockLampu" />
                    <span class="text-danger font-italic">{{errors[0]}}</span>
                </validation-provider>
                <br />

                <button class="btn btn-primary" type="submit">
                    <fa-icon icon="check"></fa-icon>
                    Submit
                </button>
            </form>
        </validation-observer>
    </div>
</template>

<script lang="ts">
    import Vue from 'vue';
    import Component from 'vue-class-component';
    import { LampuService, LampuModel } from '../services/NSwagService';
    import swal from 'sweetalert2';

    @Component({
        created: async function (this: UpdateEmployee) {
            await this.getSpecificLamp()
        }
    })

    export default class UpdateEmployee extends Vue {
        service: LampuService = new LampuService();

        newLamp: LampuModel = {
           namaLampu: '',
           stockLampu = 0
        }

        async getSpecificLamp(): Promise<void> {
            const urlParams = new URLSearchParams(window.location.search);
            const IdLampu = urlParams.get('IdLampu')?.valueOf();
            this.newLamp = await this.service.getSpesificLamp(IdLampu);
        }

        async updateLamp(): Promise<void> {
            swal.fire({
                title: 'Are you sure?',
                text: "Update this employee data",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, update it!'
            }).then(async (result) => {
                if (result.value) {

                    await this.service.updateLamp(this.newLamp);
                    swal.fire(
                        'Updated!',
                        'Your file has been updated.',
                        'success'
                    )

                    window.location.href = '/lampu/indexApp?IdLampu=' + this.newLamp.idLampu;
                }
            })
        }


    }
</script>