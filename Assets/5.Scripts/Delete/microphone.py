import pyaudio
import wave
import os
import keyboard
con = 1
class MicrophoneRecorder:
    def __init__(self, output_file_path='./Assets/8.Data/output.wav', channels=1, sample_rate=44100, chunk_size=1024):
        self.output_file_path = output_file_path
        self.channels = channels
        self.sample_rate = sample_rate
        self.chunk_size = chunk_size
        self.p = pyaudio.PyAudio()

    def start_recording(self, record_seconds):
        stream = self.p.open(format=pyaudio.paInt16,
                             channels=self.channels,
                             rate=self.sample_rate,
                             input=True,
                             frames_per_buffer=self.chunk_size)

        print(f"Recording for {record_seconds} seconds...")

        frames = []
        for i in range(0, int(self.sample_rate / self.chunk_size * record_seconds)):
            data = stream.read(self.chunk_size)
            frames.append(data)
            if keyboard.is_pressed('2'):
                print("녹음 중지")
                stream.stop_stream()
                stream.close()
                self.p.terminate()
                self.save_to_wav(frames)
                con = 0;
                print("Finished recording.")
                break
        if con != 0:
            stream.stop_stream()
            stream.close()
            self.p.terminate()
            self.save_to_wav(frames)
            print("Finished recording.")
        
        
        

    def save_to_wav(self, frames):
        directory = os.path.dirname(self.output_file_path)
        if not os.path.exists(directory):
            print(f"Creating directory: {directory}")
            os.makedirs(directory)

        with wave.open(self.output_file_path, 'wb') as wf:
            wf.setnchannels(self.channels)
            wf.setsampwidth(self.p.get_sample_size(pyaudio.paInt16))
            wf.setframerate(self.sample_rate)
            wf.writeframes(b''.join(frames))

# Example of using the MicrophoneRecorder class
if __name__ == "__main__":
    recorder = MicrophoneRecorder(output_file_path='./Assets/8.Data/output.wav')
    recorder.start_recording(record_seconds=30)

