import { notify } from "@kyvg/vue3-notification";

export default {
    success(title, message){
        notify({
            title: title,
            text: message,
            type: 'success',
            duration: 2000,
            speed: 300
          });
    }
}