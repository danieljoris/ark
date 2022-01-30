from domain.enums.payment_type import PaymentType
from domain.value_objects.core.value_object import ValueObject


class PaymentInformation(ValueObject):
    payment_type: PaymentType
    payment_value: float
